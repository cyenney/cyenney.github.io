<template>
    <h2>Login</h2>
    <el-row>
        <el-input class="input-field" v-model="email" placeholder="Email" />
    </el-row>
    <el-row>
        <el-input class="input-field" v-model="password" placeholder="Please input" />
    </el-row>
    <div v-if="notFound">
        Incorrect email or password.
    </div>
    <el-row>
        <el-button v-on:click="login" type="primary">Primary</el-button>
    </el-row>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import axios from 'axios'

    export default defineComponent({
        data() {
            return {
                email:null,
                password: null,
                notFound:false,
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
            login() {
                let self = this;
                axios.post('Customers/login', {
                    email: this.email,
                    password: this.password
                  })
                    .then(function (response) {
                        if (response.status == 200) {
                            self.notFound = false;
                            self.$router.push({ name: 'Dashboard', params: { id: response.data } });
                        } else {
                            self.notFound = true;
                        }
                   
                  })
                    .catch(function (error) {
                        self.notFound = true;
                    console.log(error);
                  });

            },
           
        },
    });
</script>

<style>
    .input-field{
        width:250px;
    }
</style>