<script setup>

const colorMode = useColorMode()

const isDark = computed({
  get () {
    return colorMode.value === 'dark'
  },
  set () {
    colorMode.preference = colorMode.value === 'dark' ? 'light' : 'dark'
  }
})
</script>

<template>
  <ClientOnly>
    <button

      aria-label="Theme"
      class="dark:text-white text-white"
      @click="isDark = !isDark"
    >
      <IconsMoon v-if="isDark" />
      <IconsSun v-else />
    </button>

    <template #fallback>
      <div class="w-8 h-8" />
    </template>
  </ClientOnly>
</template>
