<template>
    <div class="container">
        <div>My link: Survey link</div>
        <el-button v-on:click="createSurvey">
            Create Survey
        </el-button>
        <div class="table-header">
            <h2>Surveys</h2>
            <el-input v-model="search" class="input-field" size="small" placeholder="Type to search" />
        </div>
        <el-table :data="tableData" style="width: 100%">
            <el-table-column label="Date" prop="date" />
            <el-table-column label="Name" prop="name" />
            <el-table-column label="Address" property="address" />

        </el-table>
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
            
        },
        watch: {
           
        },
        methods: {
            createSurvey() {
                this.$router.push({ name: 'CreateSurvey' });
            },

        },
    });
</script>

<style scoped>

    .container{
        padding:5px;
    }
    .table-header {
        justify-content: space-between;
        display: flex;
    }
</style>