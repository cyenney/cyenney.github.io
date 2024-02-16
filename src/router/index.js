import { createWebHistory, createRouter } from 'vue-router'
import Home from '../views/LandingPage.vue'
//import About from '../views/about-page.vue'
import LogIn from '../views/LogIn.vue'
import HomePage from '../views/HomePage.vue'

const routes = [
    { path: '/', name: 'Home', component: Home },
    //{ path: '/about', name: 'About', component: About },
    { path: '/login', name: 'LogIn', component: LogIn },
    { path: '/homepage/:id', name: 'HomePage', component: HomePage }

];
const router = createRouter({
    history: createWebHistory(),
    routes
})

export default router