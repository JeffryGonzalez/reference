// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  css: [
    '@/assets/css/main.css'
  ],
  devtools: { enabled: true },
  modules: [

    '@nuxtjs/eslint-module'
  ],
  eslint: {
    lintOnStart: false
  },
  devServer: {
    port: 3008
  },
  postcss: {
    plugins: {
      tailwindcss: {},
      autoprefixer: {}
    }
  }
})
