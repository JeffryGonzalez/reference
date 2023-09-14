// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  css: [
    '@/assets/css/main.css'
  ],
  devtools: { enabled: true },
  modules: [
    '@nuxtjs/color-mode',
<<<<<<< HEAD
    '@nuxtjs/eslint-module',
    'nuxt-icon'
=======
    '@nuxtjs/eslint-module'
>>>>>>> b1ded28 (set)
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
  },
  colorMode: {
    preference: 'system', // default value of $colorMode.preference
    fallback: 'light', // fallback value if not system preference found
    hid: 'nuxt-color-mode-script',
    globalName: '__NUXT_COLOR_MODE__',
    componentName: 'ColorScheme',
    classPrefix: '',
    classSuffix: '',
    storageKey: 'nuxt-color-mode'
  }
})
