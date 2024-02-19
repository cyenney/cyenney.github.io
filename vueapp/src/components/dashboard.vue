<template>
    <div class="container">
        <el-row class="card-row">
            <!--<el-tabs v-model="activeName" class="demo-tabs" @tab-click="handleClick">
        <el-tab-pane class="tab" label="Comments" name="first">
            <div class="table-header">
                <h2>Comments</h2>
                <el-input v-model="search" class="input-field" size="small" placeholder="Type to search" />
            </div>

            <el-table :data="tableData" style="width: 100%">

                <el-table-column label="Date" prop="date" />
                <el-table-column label="Name" prop="name" />
                <el-table-column label="Address" property="address" />

            </el-table>
        </el-tab-pane>
        <el-tab-pane label="Config" name="second">Config</el-tab-pane>
        <el-tab-pane label="Role" name="third">Role</el-tab-pane>
        <el-tab-pane label="Task" name="fourth">Task</el-tab-pane>
    </el-tabs>-->
            <el-badge :value="12" class="item">
                <el-button>Comments</el-button>
            </el-badge>
            <el-card class="box-card">
                <template #header>
                    <div class="card-header">
                        <span>Surveys</span>
                        <el-button class="button" text>Operation button</el-button>
                    </div>
                </template>
                <div v-for="o in 4" :key="o" class="text item">{{ 'List item ' + o }}</div>
            </el-card>
            <el-card class="box-card">
                <template #header>
                    <div class="card-header">
                        <span>Comments</span>
                        <el-button class="button" text>Operation button</el-button>
                    </div>
                </template>
                <div v-for="o in 4" :key="o" class="text item">{{ 'List item ' + o }}</div>
            </el-card>
        </el-row>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import { computed, ref } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                post: null,
                search:'',
                tableData: [
                    {
                    date: '2016-05-03',
                    name: 'Tom',
                    address: 'No. 189, Grove St, Los Angeles',
                  },
                  {
                    date: '2016-05-02',
                    name: 'John',
                    address: 'No. 189, Grove St, Los Angeles',
                  },
                  {
                    date: '2016-05-04',
                    name: 'Morgan',
                    address: 'No. 189, Grove St, Los Angeles',
                  },
                  {
                    date: '2016-05-01',
                    name: 'Jessy',
                    address: 'No. 189, Grove St, Los Angeles',
                  },
                ]
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            //this.fetchData();
        },
        computed: {
           
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            /*fetchData() {
            //  this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }*/
        },
    });
</script>

<style scoped>

    .input-field {
        width: 300px;
    }

    .el-tabs__item.is-active {
        color:black;
    }

    .demo-tabs {
        width: 60%;
        height: 100%;
        background-color:white;
    }
    .container {
        padding:5px;
    }

    .card-row {
        justify-content: space-between;
        padding-top: 10px;
    }

    .card-header {
        display: flex;
        justify-content: space-between;
        align-items: center;
    }

    .tab {
        color:black;
    }

    .tab:active {
        color:black;
    }
    .table-header{
        justify-content:space-between;
        display:flex;
    }
    .text {
        font-size: 14px;
    }

    .item {
        margin-bottom: 18px;
    }

    .box-card {
        width: 400px;
        height:300px;
    }

    .badge {
        margin-top: 10px;
        margin-right: 40px;
    }
</style>