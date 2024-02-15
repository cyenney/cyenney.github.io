import { createApp } from "vue";
import App from './App.vue'     //Our .vue startup file
import './static/global.css'    //Import css files as modules
import ElementPlus from 'element-plus'
import 'element-plus/dist/index.css'
import router from './router'
import axios from 'axios';
import bootstrap from 'bootstrap';
axios.defaults.baseURL = 'https://localhost:7135';


const app = createApp(App);
app.use(ElementPlus).use(router).use(bootstrap);
app.mount('#app')