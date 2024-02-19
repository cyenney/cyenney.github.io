<template>
    <div class="container">
        <el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
            <el-tab-pane class="tab" label="Create a new survey" name="first">
                <div>Create a survey</div>
                <div>
                    <el-row class="row" v-for="n in numberOfQuestions">
                        <el-col :span="12">
                            <div>Question</div>
                            <div><el-input /></div>
                        </el-col>

                        <el-col :span="12">
                            <el-row>
                                <div>Type</div>
                                <el-select v-model="value"
                                           class="m-2"
                                           placeholder="Select"
                                           size="large"
                                           style="width: 240px">
                                    <el-option v-for="item in options"
                                               :key="item.value"
                                               :label="item.label"
                                               :value="item.value" />
                                </el-select>
                            </el-row>
                            <div v-if="value === 'input'">
                                <el-input/>
                            </div>
                            <div v-else-if="value === 'rate'">
                                <el-rate v-model="value"
                                         side="large"
                                         :texts="['oops', 'disappointed', 'normal', 'good', 'great']"
                                         show-text />
                            </div>
                            <div v-else-if="value === 'slider'">
                                <el-slider v-model="slider" />
                            </div>
                            <div v-else-if="value === 'toggle'">
                                <el-switch v-model="toggle" />
                            </div>
                            <div v-else-if="value === 'checkbox'">
                                <el-checkbox-group v-model="form.type">
                                    <el-checkbox label="Online activities" name="type" />
                                    <el-checkbox label="Promotion activities" name="type" />
                                    <el-checkbox label="Offline activities" name="type" />
                                    <el-checkbox label="Simple brand exposure" name="type" />
                                </el-checkbox-group>
                            </div>
                        </el-col>
                    </el-row>
                </div>
                
                <el-button v-on:click="addQuestion">Add another question</el-button>
            </el-tab-pane>
            <el-tab-pane class="tab" label="Example survey" name="second">
                <div>Example survey</div>
                <el-form :model="form" label-width="120px">
                    <el-form-item label="Activity name">
                        <el-input :rows="2"
                                    type="textarea"
                                  v-model="form.name" />
                    </el-form-item>
                    <el-form-item label="Activity zone">
                        <el-select v-model="form.region" placeholder="please select your zone">
                            <el-option label="Zone one" value="shanghai" />
                            <el-option label="Zone two" value="beijing" />
                        </el-select>
                    </el-form-item>
                    <el-form-item label="Activity time">
                        <el-col :span="11">
                            <el-date-picker v-model="form.date1"
                                            type="date"
                                            placeholder="Pick a date"
                                            style="width: 100%" />
                        </el-col>
                        <el-col :span="2" class="text-center">
                            <span class="text-gray-500">-</span>
                        </el-col>
                        <el-col :span="11">
                            <el-time-picker v-model="form.date2"
                                            placeholder="Pick a time"
                                            style="width: 100%" />
                        </el-col>
                    </el-form-item>
                    <el-form-item label="Instant delivery">
                        <el-switch v-model="form.delivery" />
                    </el-form-item>
                    <el-form-item label="Activity type">
                        <el-checkbox-group v-model="form.type">
                            <el-checkbox label="Online activities" name="type" />
                            <el-checkbox label="Promotion activities" name="type" />
                            <el-checkbox label="Offline activities" name="type" />
                            <el-checkbox label="Simple brand exposure" name="type" />
                        </el-checkbox-group>
                    </el-form-item>
                    <el-form-item label="Resources">
                        <el-radio-group v-model="form.resource">
                            <el-radio label="Sponsor" />
                            <el-radio label="Venue" />
                        </el-radio-group>
                    </el-form-item>
                    <el-form-item label="Activity form">
                        <el-input v-model="form.desc" type="textarea" />
                    </el-form-item>
                    <el-form-item>
                        <el-button type="primary" @click="onSubmit">Create</el-button>
                        <el-button>Cancel</el-button>
                    </el-form-item>
                </el-form>
            </el-tab-pane>
            
        </el-tabs>

    </div>

</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                post: null,
                slider:0,
                numberOfQuestions: 0,
                toggle:true,
                value:"",
                options: [
                    {
                        value: 'input',
                        label: 'input',
                    },
                    {
                        value: 'slider',
                        label: 'slider',
                    },
                    {
                        value: 'rate',
                        label: 'rate',
                    },
                    {
                        value: 'toggle',
                        label: 'toggle',
                    },
                    {
                        value: 'checkbox',
                        label: 'checkbox',
                    }
                ],
                questions: [

                ],
                form:({
                    name: '',
                    region: '',
                    date1: '',
                    date2: '',
                    delivery: false,
                    type: [],
                    resource: '',
                    desc: '',
                })
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            addQuestion() {
                this.numberOfQuestions = this.numberOfQuestions + 1;
            }
           
        },
    });
</script>

<style>

    .row {
        padding-top:5px;
        padding-bottom:5px;
    }
    .demo-tabs {
        background-color:white;
        padding:2px;
    }
    .tab {
        color: black;
    }

</style>