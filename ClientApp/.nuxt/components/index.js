export { default as FooterApp } from '../../components/FooterApp.vue'
export { default as Logo } from '../../components/Logo.vue'
export { default as NavBar } from '../../components/NavBar.vue'
export { default as SideBar } from '../../components/SideBar.vue'
export { default as AdminFooter } from '../../components/Admin/AdminFooter.vue'
export { default as AdminNav } from '../../components/Admin/AdminNav.vue'
export { default as AdminSide } from '../../components/Admin/AdminSide.vue'
export { default as FormInput } from '../../components/Forms/FormInput.vue'

export const LazyFooterApp = import('../../components/FooterApp.vue' /* webpackChunkName: "components/footer-app" */).then(c => c.default || c)
export const LazyLogo = import('../../components/Logo.vue' /* webpackChunkName: "components/logo" */).then(c => c.default || c)
export const LazyNavBar = import('../../components/NavBar.vue' /* webpackChunkName: "components/nav-bar" */).then(c => c.default || c)
export const LazySideBar = import('../../components/SideBar.vue' /* webpackChunkName: "components/side-bar" */).then(c => c.default || c)
export const LazyAdminFooter = import('../../components/Admin/AdminFooter.vue' /* webpackChunkName: "components/admin-footer" */).then(c => c.default || c)
export const LazyAdminNav = import('../../components/Admin/AdminNav.vue' /* webpackChunkName: "components/admin-nav" */).then(c => c.default || c)
export const LazyAdminSide = import('../../components/Admin/AdminSide.vue' /* webpackChunkName: "components/admin-side" */).then(c => c.default || c)
export const LazyFormInput = import('../../components/Forms/FormInput.vue' /* webpackChunkName: "components/form-input" */).then(c => c.default || c)
