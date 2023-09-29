<script setup lang="ts">
import { TodoItem } from '@/models';
interface Props {
    items: TodoItem[]
}
const props = defineProps<Props>();
const events = defineEmits<{
    completed: [item:TodoItem]
}>()

const { items } = props;
</script>
<template>
  <ul class="list-none">
    <li v-for="item in props.items" :key="item.id" class="pb-4 border  rounded-md">
      <p class="text-xl font-bold ml-4" :class="{'line-through': item.completed}">
        {{ item.description }}
      </p>
      <div>
        <UiButton @click="$emit('completed', item)">
          X
        </UiButton>
      </div>
    </li>
  </ul>
</template>
