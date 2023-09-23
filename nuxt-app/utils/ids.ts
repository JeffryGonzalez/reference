export const getUniqueId = () => {
  return crypto.randomUUID();
}

export const formatName = (first: string, last: string) => {
  return `${last}, ${last}`
}
