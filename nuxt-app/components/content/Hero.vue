<template>
  <section class="p-6 mt-8 border bg-white dark:bg-black dark:border-gray-700 rounded">
    <h1 class="text-4xl">
      <slot />
    </h1>
    <div class="pt-4">
      <slot name="content" />
    </div>
  </section>
</template>
