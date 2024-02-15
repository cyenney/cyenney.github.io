<template>
    <div class="common-layout">
        <el-container>
            <el-header class="no-padding">
                <nav-bar></nav-bar>
            </el-header>
            <el-main>
                <router-view></router-view>
            </el-main>
        </el-container>
    </div>
</template>

<script>
    import { defineComponent } from 'vue';
    import HomePage from './components/HomePage.vue'
    import NavBar from './components/NavBar.vue'

    export default defineComponent({
        name: 'App',
        components: {
            HomePage,
            NavBar
        }
    });

</script>

<style>
    @import'~bootstrap/dist/css/bootstrap.css';
</style>

<style scoped>
    .no-padding{
        padding-left:0;
        padding-right:0;
    }
</style>