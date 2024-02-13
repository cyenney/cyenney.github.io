<template>
    <h2>{{id}}</h2>
    <h2>dashboard</h2>
</template>
<script>
    import { defineComponent } from 'vue';
    import axios from 'axios';
    export default defineComponent({
        name: "dashboard",
        data() {
            return {
                loading: false,
                post: null,
                id: this.$route.params.id
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

