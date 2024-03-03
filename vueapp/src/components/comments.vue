<template>
    <div>
        New Comment link: <router-link :to="{name: 'new-comment', params:{id:id}}">new comment</router-link>
    </div>
    <!--<el-card class="box-card">
        <template #header>
            <div class="card-header">
                <span>Card name</span>
                <el-button class="button" text>Operation button</el-button>
            </div>
        </template>
        <div v-for="o in 4" :key="o" class="text item">{{ 'List item ' + o }}</div>
        <template #footer>
            Footer content
        </template>
    </el-card>-->
    <el-table :data="tableData" style="width: 100%">
        <el-table-column prop="date" label="Date" width="180" />
        <el-table-column prop="name" label="Name" width="180" />
        <el-table-column prop="address" label="Address" />
    </el-table>

    <div>Input</div>
    <el-input v-model="comment" />
    <el-button v-on:click="submit">Submit</el-button>
    <div v-if="response">
        {{response.sentimentText}} : {{response.prediction}}
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import axios from 'axios'

    export default defineComponent({
        data() {
            return {
                loading: false,
                comment: '',
                sentimentText: null,
                prediction: null,
                response: '',
                tableData:null
                
               
            };
        },
        created() {
            this.getCustomerComments();
        },
        computed: {
            id(){
                return this.$route.params.id;
            }
        },
        watch: {
           
        },
        methods: {
            submit() {
                axios.get(`SentimentAnalysis/get-analysis/${this.comment}`).then(
                    (success) => {
                        this.response = success.data;
                        console.log(success);
                        console.log(success.data);
                        

                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            },
            getCustomerComments() {
                axios.get(`Comment/get-comments/${this.id}`).then(
                    (success) => {
                        this.response = success.data;
                        console.log(success);
                        console.log(success.data);


                    })
                    .catch(function (error) {
                        console.log(error);
                    });
            }

        },
    });
</script>