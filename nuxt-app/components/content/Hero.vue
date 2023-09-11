<template>
  <section class="p-6 m-4 border bg-white dark:bg-black dark:border-gray-700 rounded">
    <h1 class="text-4xl">
      <slot />
    </h1>
    <slot name="content" />
  </section>
</template>
