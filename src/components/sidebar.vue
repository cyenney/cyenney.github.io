<template>
    <el-menu active-text-color="#ffd04b"
             background-color="#545c64"
             class="el-menu-vertical-demo side-bar"
             default-active="1"
             text-color="#fff"
             @open="handleOpen"
             @close="handleClose">
        <h2 class="dashboard">Dashboard</h2>
        <el-menu-item @click="$emit('input', 'dashboard')" index="1">
            <span>Dashboard</span>
        </el-menu-item>
        <el-menu-item @click="$emit('input', 'survey')" index="2">
            <span>Survey</span>
        </el-menu-item>
        <el-menu-item @click="$emit('input', 'coupons')" index="3">
            <span>Coupons</span>
        </el-menu-item>
        <el-menu-item @click="$emit('input', 'profile')" index="4">
            <span>Profile</span>
        </el-menu-item>
    </el-menu>
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
        emits: ["input"],
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            
        },
        watch: {
            // call again the method if the route changes
            
        },
        methods: {
            //changeMenu(selection){
            //    this.$emit("input", selection);
            //}
        },
    });
</script>
<style>
    .side-bar {
        width: 100%;
        height:100vh;
        padding-top:5px;
        padding-left:5px;
        border-style:solid;
        border-bottom:thin;
        border-width:2px;
    }

    .dashboard {
        color:white;
    }
</style>
