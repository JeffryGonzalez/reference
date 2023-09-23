<script setup lang="ts">
import { storeToRefs } from 'pinia';
import { TodoItem } from '~/models';

const todoStore = useTodosStore();
todoStore.$onAction(({ name, store, args, after, onError }) => {
  console.log({ name, store, args, after, onError });
})
const { todos, empty } = storeToRefs(todoStore)
const { add, toggleComplete } = todoStore;

const description = ref('');
const addTodo = () => {
  add({ description: description.value });
  description.value = '';
}
const handleCompleted = (item:TodoItem) => {
  toggleComplete(item);
}
</script>
<template>
  <div class="prose">
    <h1 class="text-2xl">
      Todos
    </h1>
    <div v-if="empty">
      <p>You Don't have any Todo Items!</p>
    </div>

    <TodosTodoListItem v-else :items="todos" @completed="handleCompleted" />
    <div>
      <form @submit.prevent="addTodo">
        <div class="form-control">
          <label for="description" class="label">Description</label>
          <UiInput v-model="description" type="text" required />
        </div>
        <UiButton type="submit">
          Add
        </UiButton>
      </form>
    </div>
  </div>
</template>
