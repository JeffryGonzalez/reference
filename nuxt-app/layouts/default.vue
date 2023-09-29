<script setup>
useHead({
  htmlAttrs: {
    'data-theme': 'dracula'
  }
})

</script>
<template>
  <section class="container mx-auto">
    <ContentHeader />
    <slot />
  </section>
</template>
