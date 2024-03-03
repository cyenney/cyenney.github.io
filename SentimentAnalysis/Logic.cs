// <SnippetAddUsings>
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.ML;
using Microsoft.ML.Data;
using static Microsoft.ML.DataOperationsCatalog;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms.Text;
using System.Data;
// </SnippetAddUsings>

namespace SentimentAnalysis
{
    public class Logic
    {
        // <SnippetDeclareGlobalVariables>
        static readonly string _dataPath = "C:\\Users\\codyy\\source\\repos\\SurverySay\\SentimentAnalysis\\data\\yelp_labelled.txt";//Path.Combine(Environment.CurrentDirectory, "Data", "yelp_labelled.txt");
        // </SnippetDeclareGlobalVariables>


        public SentimentResponse GetSentimentAnalysis(string comment)
        {
            // Create ML.NET context/local environment - allows you to add steps in order to keep everything together
            // as you discover the ML.NET trainers and transforms
            // <SnippetCreateMLContext>
            MLContext mlContext = new MLContext();

            TrainTestData splitDataView = LoadData(mlContext);

            ITransformer model = BuildAndTrainModel(mlContext, splitDataView.TrainSet);

            //Evaluate(mlContext, model, splitDataView.TestSet);

            return UseModelWithSingleItem(mlContext, model, comment);

            //UseModelWithBatchItems(mlContext, model);

        }

        public static TrainTestData LoadData(MLContext mlContext)
        {
            // Note that this case, loading your training data from a file,
            // is the easiest way to get started, but ML.NET also allows you
            // to load data from databases or in-memory collections.
            // <SnippetLoadData>
            IDataView dataView = mlContext.Data.LoadFromTextFile<SentimentData>(_dataPath, hasHeader: false);
            // </SnippetLoadData>

            // You need both a training dataset to train the model and a test dataset to evaluate the model.
            // Split the loaded dataset into train and test datasets
            // Specify test dataset percentage with the `testFraction`parameter
            // <SnippetSplitData>
            TrainTestData splitDataView = mlContext.Data.TrainTestSplit(dataView, testFraction: 0.2);
            // </SnippetSplitData>

            // <SnippetReturnSplitData>
            return splitDataView;
            // </SnippetReturnSplitData>
        }

        public static ITransformer BuildAndTrainModel(MLContext mlContext, IDataView splitTrainSet)
        {
            // Create a flexible pipeline (composed by a chain of estimators) for creating/training the model.
            // This is used to format and clean the data.
            // Convert the text column to numeric vectors (Features column)
            // <SnippetFeaturizeText>
            var estimator = mlContext.Transforms.Text.FeaturizeText(outputColumnName: "Features", inputColumnName: nameof(SentimentData.SentimentText))
            //</SnippetFeaturizeText>
            // append the machine learning task to the estimator
            // <SnippetAddTrainer>
            .Append(mlContext.BinaryClassification.Trainers.SdcaLogisticRegression(labelColumnName: "Label", featureColumnName: "Features"));
            // </SnippetAddTrainer>

            // Create and train the model based on the dataset that has been loaded, transformed.
            // <SnippetTrainModel>
            var model = estimator.Fit(splitTrainSet);
            // </SnippetTrainModel>

            // Returns the model we trained to use for evaluation.
            // <SnippetReturnModel>
            return model;
            // </SnippetReturnModel>
        }

        public static void Evaluate(MLContext mlContext, ITransformer model, IDataView splitTestSet)
        {
            // Evaluate the model and show accuracy stats

            //Take the data in, make transformations, output the data.
            // <SnippetTransformData>
            IDataView predictions = model.Transform(splitTestSet);
            // </SnippetTransformData>

            // BinaryClassificationContext.Evaluate returns a BinaryClassificationEvaluator.CalibratedResult
            // that contains the computed overall metrics.
            // <SnippetEvaluate>
            CalibratedBinaryClassificationMetrics metrics = mlContext.BinaryClassification.Evaluate(predictions, "Label");
            // </SnippetEvaluate>

            // The Accuracy metric gets the accuracy of a model, which is the proportion
            // of correct predictions in the test set.

            // The AreaUnderROCCurve metric is equal to the probability that the algorithm ranks
            // a randomly chosen positive instance higher than a randomly chosen negative one
            // (assuming 'positive' ranks higher than 'negative').

            // The F1Score metric gets the model's F1 score.
            // The F1 score is the harmonic mean of precision and recall:
            //  2 * precision * recall / (precision + recall).

            // <SnippetDisplayMetrics>
            Console.WriteLine();
            Console.WriteLine("Model quality metrics evaluation");
            Console.WriteLine("--------------------------------");
            Console.WriteLine($"Accuracy: {metrics.Accuracy:P2}");
            Console.WriteLine($"Auc: {metrics.AreaUnderRocCurve:P2}");
            Console.WriteLine($"F1Score: {metrics.F1Score:P2}");
            Console.WriteLine("=============== End of model evaluation ===============");
            //</SnippetDisplayMetrics>
        }

        private static SentimentResponse UseModelWithSingleItem(MLContext mlContext, ITransformer model, string comment)
        {
            PredictionEngine<SentimentData, SentimentPrediction> predictionFunction = mlContext.Model.CreatePredictionEngine<SentimentData, SentimentPrediction>(model);
           
            SentimentData sampleStatement = new SentimentData
            {
                SentimentText = comment
            };

            var resultPrediction = predictionFunction.Predict(sampleStatement);
            return new SentimentResponse() { SentimentText = comment, Prediction = Convert.ToBoolean(resultPrediction.Prediction) ? "Positive" : "Negative" };
        }

        public static void UseModelWithBatchItems(MLContext mlContext, ITransformer model)
        {
            // Adds some comments to test the trained model's data points.
            // <SnippetCreateTestIssues>
            IEnumerable<SentimentData> sentiments = new[]
            {
                new SentimentData
                {
                    SentimentText = "This was a horrible meal"
                },
                new SentimentData
                {
                    SentimentText = "I love this spaghetti."
                }
            };
            // </SnippetCreateTestIssues>

            // Load batch comments just created
            // <SnippetPrediction>
            IDataView batchComments = mlContext.Data.LoadFromEnumerable(sentiments);

            IDataView predictions = model.Transform(batchComments);

            // Use model to predict whether comment data is Positive (1) or Negative (0).
            IEnumerable<SentimentPrediction> predictedResults = mlContext.Data.CreateEnumerable<SentimentPrediction>(predictions, reuseRowObject: false);
            // </SnippetPrediction>

            // <SnippetAddInfoMessage>
            Console.WriteLine();

            Console.WriteLine("=============== Prediction Test of loaded model with multiple samples ===============");
            // </SnippetAddInfoMessage>

            Console.WriteLine();

            // <SnippetDisplayResults>
            foreach (SentimentPrediction prediction in predictedResults)
            {
                Console.WriteLine($"Sentiment: {prediction.SentimentText} | Prediction: {prediction.Prediction} | Probability: {prediction.Probability} ");
            }
            Console.WriteLine("=============== End of predictions ===============");
            // </SnippetDisplayResults>
        }
    }
}