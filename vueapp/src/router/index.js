import { createWebHistory, createRouter } from 'vue-router'
import Home from '../views/LandingPage.vue'
import CreateSurvey from '../views/CreateSurvey.vue'
import LogIn from '../views/LogIn.vue'
import HomePage from '../views/HomePage.vue'

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/createsurvey', name: 'CreateSurvey', component: CreateSurvey },
    { path: '/login', name: 'LogIn', component: LogIn },
    { path: '/homepage/:id', name: 'HomePage', component: HomePage }

];
const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router