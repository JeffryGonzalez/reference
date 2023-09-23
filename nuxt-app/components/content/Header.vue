<script setup lang="ts">
import { themeChange } from 'theme-change';
import { onMounted } from 'vue';
const links = [
  { href: '/', name: 'home' },
  { href: '/state', name: 'State Management' }
]
onMounted(() => {
  themeChange(false)
})

</script>

<template>
  <div class="navbar bg-base-100">
    <div class="navbar-start">
      <div class="dropdown">
        <label tabindex="0" class="btn btn-ghost btn-circle">
          <svg xmlns="http://www.w3.org/2000/svg" class="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor"><path stroke-linecap="round" stroke-linejoin="round" stroke-width="2" d="M4 6h16M4 12h16M4 18h7" /></svg>
        </label>
        <ul tabindex="0" class="menu menu-sm dropdown-content mt-3 z-[1] p-2 shadow bg-base-100 rounded-box w-52">
          <li v-for="link in links" :key="link.href">
            <NuxtLink :to="link.href">
              {{ link.name }}
            </NuxtLink>
          </li>
        </ul>
      </div>
    </div>
    <div class="navbar-center">
      <a class="btn btn-ghost normal-case text-xl">Hypertheory Nuxt Demo Stuff</a>
    </div>
    <div class="navbar-end">
      <button data-toggle-theme="dracula,cupcake" data-act-class="ACTIVECLASS">
        <IconsMoon class="moon" /><IconsSun class="sun" />
      </button>
    </div>
  </div>
</template>
<style>

[data-theme="dracula"] .moon {
  display: none;
}
[data-theme="cupcake"] .sun {
  display: none;
}

</style>
