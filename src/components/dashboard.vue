<template>
    <div class="container">
        <el-row class="card-row">
            <!--<el-card class="box-card">
                <template #header>
                    <div class="card-header">
                        <span>Surveys completed</span>
                        <el-button class="button" text>Operation button</el-button>
                    </div>
                </template>
                <div v-for="o in 4" :key="o" class="text item">{{ 'List item ' + o }}</div>
                <template #footer>
                    Footer content
                </template>
            </el-card>-->
            <el-badge :value="12" class="badge">
                <el-button>comments</el-button>
            </el-badge>
            <el-badge :value="3" class="badge">
                <el-button>replies</el-button>
            </el-badge>
            <el-badge :value="1" class="badge" type="primary">
                <el-button>comments</el-button>
            </el-badge>
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
            <el-card class="box-card">
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
            </el-card>
        </el-row>
    </div>
</template>

<script lang="js">
    import { defineComponent } from 'vue';

    export default defineComponent({
        data() {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            //this.fetchData();
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