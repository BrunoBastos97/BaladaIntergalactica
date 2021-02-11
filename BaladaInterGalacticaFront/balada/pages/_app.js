import '../styles/globals.css'
import {createGlobalStyle, ThemeProvider} from 'styled-components'

const GlobalStyle = createGlobalStyle

function MyApp({ Component, pageProps }) {
  return <Component {...pageProps} />
}

export default MyApp
