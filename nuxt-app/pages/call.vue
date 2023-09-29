<script setup lang="ts">
const data = await useFetch('/api/counter')

</script>
<template>
  <pre>{{ data }}</pre>
</template>
