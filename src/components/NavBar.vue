<template>
    <div class="h-6" />
    <el-menu :default-active="activeIndex2"
             class="el-menu-demo"
             mode="horizontal"
             background-color="#FFA500"
             text-color="#fff"
             active-text-color="#ffd04b"
             @select="handleSelect"
             style="justify-content:space-between">
        <el-menu-item index="1"><router-link to="/">SurveySays</router-link></el-menu-item>
        <el-sub-menu index="2">
            <template #title>
                Account
            </template>
            <el-menu-item index="2-1" @click="login">Log in</el-menu-item>
            <el-menu-item index="2-2">Sign up</el-menu-item>
        </el-sub-menu>
    </el-menu>
</template>
<script>
    import { defineComponent } from 'vue';
    export default defineComponent({
        name: "navbar",
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
            login() {
                this.$router.push({ name: 'LogIn' })
            },
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

