import { createApp, createRouter, eventHandler, fromNodeMiddleware, handleCors } from "h3";
import { getRoutes } from "./todos/handler";
import { useCors } from "./cors";
import { logRequests } from "./middlewares";

const app = createApp();
app.use(logRequests);
app.use(useCors());

const router = createRouter();

getRoutes("/todos", router);

export default app.use(router);


  