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
    <Button

      class="dark:text-slate-100  text-slate-900"
      aria-label="Theme"
      @click="isDark = !isDark"
    >
      <IconsMoon v-if="isDark" />
      <IconsSun v-else />
    </Button>

    <template #fallback>
      <div class="w-8 h-8" />
    </template>
  </ClientOnly>
</template>
