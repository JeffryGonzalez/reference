import { H3CorsOptions, eventHandler, handleCors } from "h3";

export const useCors = (options:H3CorsOptions = {}) => eventHandler(event => {
    const opts = {...options, ...{
        allowHeader: '*',
        methods: '*',
        origin: '*'
    }} as H3CorsOptions;
    handleCors(event, opts)
})