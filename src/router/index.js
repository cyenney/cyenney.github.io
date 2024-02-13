import { createWebHistory, createRouter } from 'vue-router'
import Home from '../components/HomePage.vue'
import About from '../views/about-page.vue'
import LogIn from '../components/LogIn.vue'
import Dashboard from '../components/dashboard.vue'

const routes = [
    { path: '/', name: 'Home', component: Home },
    { path: '/about', name: 'About', component: About },
    { path: '/login', name: 'LogIn', component: LogIn },
    { path: '/dashboard/:id', name: 'Dashboard', component: Dashboard }

];
const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router