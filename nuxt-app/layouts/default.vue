<template>
<<<<<<< HEAD
  <section>
    <header>
      <ColorMode />
    </header>
    <div />
=======
  <section class="container mx-auto">
    <div>
      <ColorMode />
    </div>
>>>>>>> b1ded28 (set)
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
