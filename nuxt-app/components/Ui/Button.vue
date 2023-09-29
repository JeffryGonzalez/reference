<script setup lang="ts">
    interface Props {
        intent?: 'primary' | 'secondary'
    };
const props = withDefaults(defineProps<Props>(), {
  intent: 'primary'
})

</script>
<template>
  <button
    class="btn"
    :class="{ 'btn-primary': props.intent === 'primary', 'btn-secondary': props.intent ==='secondary'}"
  >
    <slot />
  </button>
</template>
