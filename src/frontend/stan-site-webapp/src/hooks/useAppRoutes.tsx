import { createBrowserRouter } from 'react-router'

const useAppRoutes = () => {
    const appRoutes = createBrowserRouter([
        {
            path: "/",
            children: []
        }
    ])

    return appRoutes;
}

export { useAppRoutes }