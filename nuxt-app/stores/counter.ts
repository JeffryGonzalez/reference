export const useCounterStore = defineStore({
  id: 'counter-store',
  state: () => {
    return {
      current: 0,
      by: 1
    }
  },
  getters: {
    isAtBeginning: state => state.current - state.by < 0
  },
  actions: {
    increment () {
      this.current += this.by
    },
    decrement () {
      this.current -= this.by
    },
    setCountBy (by: 1 | 3 | 5) {
      this.by = by
    }
  }
});

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useCounterStore, import.meta.hot));
}
