import Image from 'next/image'
import { Inter } from 'next/font/google'
import { Button } from "@/components/ui/button"

const inter = Inter({ subsets: ['latin'] })

export default function Home() {
  return (
    <>   
  <div className='flex items-center justify-center'><Button variant="outline" className='mx-20'>Button</Button></div>
  <div> Hej</div>
  </>
  )
}
