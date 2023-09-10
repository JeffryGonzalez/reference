import { fromNodeMiddleware } from "h3";

export const logRequests = fromNodeMiddleware((req,res,next) => {
    console.log(`${req.method}: ${req.url}`);
    next();
})