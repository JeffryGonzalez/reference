# CSS Units
[[CSS]] [[Accessibility]]
## Rem
Stands for "Root Elements Font Size" - usually 16px, but can be changed for and by accessibility.

So:

```css

h1 {
	font-size: 2rem;
}
```

Means you want it twice as big as the root element size of 16px (e.g. 32px here).

## Em
"Parent Elements Font Size"

```html

<div>
  <p>hi</p>
</div>

<style>
  div {
    font-size: 0.5rem; // 8px
  }

  p {
    font-size: 1em; // ??px == 8px
  }
</style>

```

Useful for padding and margin, mostly.

The problem with Pixels is they are DEFINITE. They don't scale if the user changes their base font size for accessibility, etc.