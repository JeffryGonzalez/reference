type Response = {
    current: number,
    by: number
}
export default defineEventHandler<Response>((event) => {
  return {
    current: 1,
    by: 1
  }
})
