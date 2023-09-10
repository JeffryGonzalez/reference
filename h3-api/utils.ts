import { H3Event, setResponseStatus } from "h3"

export function sendResponseOrFourOhFour<T>(event: H3Event, entity:T) {
    if(entity === null || entity === undefined) {
        setResponseStatus(event, 404);
        return;
    } else {
        return entity;
    }
}