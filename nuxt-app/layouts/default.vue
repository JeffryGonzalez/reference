<template>
  <section>
    <header>
      <ColorMode />
    </header>
    <div />
    <slot />
  </section>
</template>
<script setup>
useHead({
  bodyAttrs: {
    class: 'bg-slate-10 dark:bg-slate-900'
  }
})
</script>
