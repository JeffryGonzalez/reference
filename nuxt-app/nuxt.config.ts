// https://nuxt.com/docs/api/configuration/nuxt-config
export default defineNuxtConfig({
  css: [
    '@/assets/css/main.css'
  ],
  imports: {
    dirs: ['stores']
  },
  app: {
    layoutTransition: { name: 'layout', mode: 'out-in' },
    pageTransition: {
      name: 'page',
      mode: 'out-in',
      duration: {
        enter: 300,
        leave: 100
      }
    }
  },
  devtools: {
    enabled: true,

    timeline: {
      enabled: true
    }
  },
  modules: [
    '@nuxtjs/color-mode',
    '@pinia/nuxt',
    '@nuxtjs/eslint-module',
    'nuxt-icon'

  ],
  pinia: {
    autoImports: [
      'defineStore', 'acceptHMRUpdate'
    ]
  },
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
