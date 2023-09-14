<script setup lang="ts">
import { storeToRefs } from 'pinia';

const todoStore = useTodosStore();
const { todos } = storeToRefs(todoStore)
const { add } = todoStore;

const description = ref('');
const addTodo = () => {
  add({ description: description.value });
  description.value = '';
}
</script>
<template>
  <div>
    <h1>Todos</h1>
    <pre>{{ todos }}</pre>

    <div>
      <form @submit.prevent="addTodo">
        <label for="description">Description</label>
        <input v-model="description" type="text" required class="text-black">
        <button type="submit">
          Add
        </button>
      </form>
    </div>
  </div>
</template>
