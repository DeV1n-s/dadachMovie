export { default as FooterApp } from '../../components/FooterApp.vue'
export { default as Logo } from '../../components/Logo.vue'
export { default as NavBar } from '../../components/NavBar.vue'
export { default as SideBar } from '../../components/SideBar.vue'

export const LazyFooterApp = import('../../components/FooterApp.vue' /* webpackChunkName: "components/footer-app" */).then(c => c.default || c)
export const LazyLogo = import('../../components/Logo.vue' /* webpackChunkName: "components/logo" */).then(c => c.default || c)
export const LazyNavBar = import('../../components/NavBar.vue' /* webpackChunkName: "components/nav-bar" */).then(c => c.default || c)
export const LazySideBar = import('../../components/SideBar.vue' /* webpackChunkName: "components/side-bar" */).then(c => c.default || c)
