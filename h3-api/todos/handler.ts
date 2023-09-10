import { Todoitem } from "@prisma/client";
import { Router, createRouter, defineEventHandler, getRouterParam, readBody, setResponseStatus, useBase } from "h3";
import { prisma } from "../client";
import { sendResponseOrFourOhFour } from "../utils";

type TodoItemCreate = Pick<Todoitem, 'description'>;

const get = defineEventHandler(async () => {
    const todos = await prisma.todoitem.findMany();
    return {
        data: todos
    }
});

const post = defineEventHandler(async (event) => {
    const body = await readBody<TodoItemCreate>(event);
    const todo = await prisma.todoitem.create({
        data: {
            description: body.description
        }
    })

    return decorate(todo);
});

const getItem = defineEventHandler(async (event) => {

    const id = await getRouterParam(event, 'todoid');

    var todo = await prisma.todoitem.findUnique({
        where: {
            id: id
        }
    });

    return sendResponseOrFourOhFour(event, todo);


});


export const getRoutes = (base: string, router: Router) => {
    const url = urlMaker(base);
    router.get(url('/'), get);
    router.post(url('/'), post);
    router.get(url('/:todoid'), getItem);
}

function urlMaker(base: string) {
    return (path: string) => base + path;
}
type Link = {
    href: string;
    method: string;
}
type Links = Record<string, string | Link>;

function decorate(item:Todoitem) : Todoitem & {_links: Links}{
    const base = 'http://localhost:3000/todos/';
    const links = {
        _self:   base +item.id,
        todos: base,
        remove: {
            href: base + item.id,
            method: 'DELETE'
        }
    }
    const result = {...item,  _links: links};
    return result;
}