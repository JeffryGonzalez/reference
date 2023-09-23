import { TodoItem } from '@/models'

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
  getters: {
    empty: state => state.todos.length === 0
  },
  actions: {
    add (item:Pick<TodoItem, 'description'>) {
      const id = getUniqueId();
      const itemToAdd:TodoItem = { id, completed: false, ...item };
      this.todos = [itemToAdd, ...this.todos]
    },
    toggleComplete (item:TodoItem) {
      const ts = [...this.todos];
      const i = ts.find(t => t.id === item.id);
      if (i) {
        i.completed = !i.completed;
      }
      this.todos = [...ts]
    }

  }
})

if (import.meta.hot) {
  import.meta.hot.accept(acceptHMRUpdate(useTodosStore, import.meta.hot));
}
