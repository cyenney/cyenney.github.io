<template>
    <div id="home">
        <el-row class="jumbotron-row">
            <div class="jumbotron">
                <h1>Bootstrap Tutorial</h1>
                <p>
                    Bootstrap is the most popular HTML, CSS, and JS framework for developing
                    responsive, mobile-first projects on the web.
                </p>
            </div>
        </el-row>
       
    </div>
    <el-row class="card-row">
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
        
</template>

<script>
    import { defineComponent } from 'vue';

    export default defineComponent({
        components: {
        },
        data() {
            return {
                loading: false,
                post: null
            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.fetchData();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            fetchData() {
                this.post = null;
                this.loading = true;

                fetch('weatherforecast')
                    .then(r => r.json())
                    .then(json => {
                        this.post = json;
                        this.loading = false;
                        return;
                    });
            }
        },
    });
</script>

<style scoped>
    .container {
        width: 100%;
        margin:0px;
    }

    .jumbotron-row {
        width:100%;
    }

    .jumbotron{
        background-color:gray;
        height:300px;
        width:100%;
    }

    .card-row{
        justify-content:space-between;
        padding-top:10px;
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
        width: 450px;
    }
</style>