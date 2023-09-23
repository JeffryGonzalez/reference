<script setup>
import { storeToRefs } from 'pinia';
const countStore = useCounterStore();
const { current, isAtBeginning, by } = storeToRefs(countStore);
const { increment, decrement, setCountBy } = countStore;
</script>
<template>
  <div>
    <h1>State Stuff</h1>
    <div class="flex flex-row items-baseline">
      <UiButton intent="secondary" :disabled="isAtBeginning" @click="decrement">
        -
      </UiButton>
      <p class="text-3xl">
        {{ current }}
      </p>
      <UiButton class="border-3 p-4 bg-slate-600 m-4" @click="increment">
        +
      </UiButton>
    </div>
    <div>
      <UiButton :disabled="by === 1" @click="setCountBy(1)">
        Count By 1
      </UiButton>
      <UiButton :disabled="by === 3" @click="setCountBy(3)">
        Count By 3
      </UiButton>
      <UiButton :disabled="by === 5" @click="setCountBy(5)">
        Count By 5
      </UiButton>
    </div>
  </div>
</template>
