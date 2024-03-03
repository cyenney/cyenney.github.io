<template>
    <el-form :model="form" label-width="auto" style="max-width: 600px">
        <el-form-item label="Name">
            <el-input v-model="form.name" />
        </el-form-item>

        <el-form-item label="Email">
            <el-input v-model="form.email" />
        </el-form-item>

        <el-form-item label="Phone Number">
            <el-input v-model="form.phoneNumber" />
        </el-form-item>

        <el-form-item label="Comment">
            <el-input v-model="form.comment" type="textarea" />
        </el-form-item>

        <el-form-item>
            <el-button type="primary" @click="onSubmit">Submit</el-button>
        </el-form-item>
    </el-form>
</template>

<script lang="js">
    import { defineComponent } from 'vue';
    import axios from 'axios'

    export default defineComponent({
        data() {
            return {
                loading: false,
                form: {
                    name: null,
                    email: null,
                    phoneNumber: null,
                    comment: null,
                },
                  
               
            };
        },
        created() {
           
        },
        watch: {
           
        },
        methods: {
            onSubmit() {
                let self = this;
                axios.post('Comment/create', {
                    customerId: this.$route.params.id,
                    email: this.form.email,
                    name:this.form.name,
                    phoneNumber: this.form.phoneNumber,
                    comment:this.form.comment
                  })
                    .then(function (response) {
                        if (response.status == 200) {
                            self.notFound = false;
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
    .el-form-item {
        color:black;
    }
</style>