<template>
    <el-row>
        <el-col :span="4">
            <side-bar @input="selectMenu" />
        </el-col>
        <el-col :span="20">
            <div v-if="selected === 'dashboard'">
                <dashboard/>
            </div>
            <div v-else-if="selected === 'profile'">
                profile
            </div>
            <div v-else-if="selected === 'surveys'">
                <survey/>
            </div>
            <div v-else-if="selected === 'comments'">
                <comments/>
            </div>
        </el-col>
    </el-row>
    
    <div></div>
</template>
<script>
    import { defineComponent } from 'vue';
    import axios from 'axios';
    import SideBar from '../components/sidebar.vue';
    import Dashboard from "../components/dashboard.vue"
    import Survey from "../components/survey.vue";
    import Comments from "../components/comments.vue";
    export default defineComponent({
        name: "home-page",
        components: {
            SideBar,
            Dashboard,
            Survey,
            Comments
        },
        data() {
            return {
                loading: false,
                post: null,
                id: this.$route.params.id,
                selected:'dashboard',
                options:[
                    "dashboard",
                    "profile",
                    "coupons",
                ]


            };
        },
        created() {
            // fetch the data when the view is created and the data is
            // already being observed
            this.getCustomerDashboard();
        },
        watch: {
            // call again the method if the route changes
            '$route': 'fetchData'
        },
        methods: {
            login() {
                this.$router.push({ name: 'LogIn' })
            },
            selectMenu(selection){

                console.log("test");
                this.selected = selection;
            },
            getCustomerDashboard() {

                let self = this;
                axios.post('Customers/login', {
                    email: this.email,
                    password: this.password
                })
                    .then(function (response) {
                        if (response.status == 200) {
                            self.$router.push({ name: 'dashboard', params: { id: response.data } });
                        }

                    })
                    .catch(function (error) {
                        console.log(error);
                    });

            }
        },
    });
</script>

