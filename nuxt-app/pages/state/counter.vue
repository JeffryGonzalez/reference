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
      <button :disabled="isAtBeginning" class="border-3 p-4 bg-slate-600 m-4 disabled:bg-slate-400" @click="decrement">
        -
      </button>
      <p class="text-3xl">
        {{ current }}
      </p>
      <button class="border-3 p-4 bg-slate-600 m-4" @click="increment">
        +
      </button>
    </div>
    <div>
      <button :disabled="by === 1" class="border-3 p-4 bg-slate-600 m-4  disabled:bg-slate-400" @click="setCountBy(1)">
        Count By 1
      </button>
      <button :disabled="by === 3" class="border-3 p-4 bg-slate-600 m-4  disabled:bg-slate-400" @click="setCountBy(3)">
        Count By 3
      </button>
      <button :disabled="by === 5" class="border-3 p-4 bg-slate-600 m-4  disabled:bg-slate-400" @click="setCountBy(5)">
        Count By 5
      </button>
    </div>
  </div>
</template>
