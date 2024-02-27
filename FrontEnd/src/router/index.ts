import { createRouter, createWebHistory } from "vue-router"
//import CarteleraView from "../views/CarteleraView.vue"
import AboutUsView from "../views/AboutUsView.vue"
import CarteleraView from "../views/CarteleraView.vue"
import HorarioView from "../views/HorarioView.vue"
import ReservaView from "../views/ReservaView.vue"
import CompraView from "../views/CompraView.vue"
import EntradaView from "../views/EntradaView.vue"
import HomeView from "../views/HomeView.vue"
import 'bootstrap/dist/css/bootstrap.min.css';
import 'font-awesome/css/font-awesome.min.css';


const router = createRouter({
    history: createWebHistory(import.meta.env.BASE_URL),
    routes: [
        {
            path: '/',
            name:'home',
            component: HomeView
        },
        {
            path: '/cartelera',
            name: 'cartelera',
            component: CarteleraView
        },
        {
            path: '/horario',
            name: 'horario',
            component: HorarioView
        },
        {
            path: '/reserva',
            name: 'reserva',
            component: ReservaView
        },
        {
            path: '/compra',
            name: 'compra',
            component: CompraView
        },
        {
            path: '/entrada',
            name: 'entrada',
            component: EntradaView
        },
        {
            path: '/about',
            name: 'about',
            component: AboutUsView
        }
    ]
})

export default router