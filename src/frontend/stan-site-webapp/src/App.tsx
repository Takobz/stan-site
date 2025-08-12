import { useState } from 'react'
import reactLogo from './assets/react.svg'
import viteLogo from '/vite.svg'
import './App.css'
import AppHeader from './components/layout/AppHeader'

function App() {
  const [count, setCount] = useState(0)

  return (
    <>
      <AppHeader/>
    </>
  )
}

export default App
