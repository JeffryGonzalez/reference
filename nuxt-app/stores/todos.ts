type TodoItem = {
    id: string,
    description: string;
    completed: boolean
}

type TodosState = {
    todos: TodoItem[]
}

export const useTodosStore = defineStore({
  id: 'todos-store',
  state: ():TodosState => {
    return {
      todos: []
    }
  },
  actions: {
    add (item:Pick<TodoItem, 'description'>) {
      const itemToAdd:TodoItem = { id: '99', completed: false, ...item };
      this.todos = [itemToAdd, ...this.todos]
    }
  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useTodosStore, import.meta.hot));
}
