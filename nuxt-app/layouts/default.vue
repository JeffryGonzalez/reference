<template>
  <section class="container mx-auto text-black dark:text-white">
    <div>
      <ColorMode />
    </div>

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
