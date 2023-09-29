<script setup lang="ts">
interface Props {
    modelValue: string | number
}
// defineProps(['modelValue'])
defineEmits(['update:modelValue'])
withDefaults(defineProps<Props>(), {
  modelValue: ''
})
</script>

<template>
  <input :value="modelValue" class="input input-primary" @input="$emit('update:modelValue', $event.target.value)">
</template>
