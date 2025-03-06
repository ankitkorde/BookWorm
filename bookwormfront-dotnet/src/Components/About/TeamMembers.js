import { useState, useEffect } from "react";
import { motion, AnimatePresence } from "framer-motion";

const teamMembers = [
  { name: "Prashant Gour", image: "TeamMember1" },
  { name: "Sanket Paithankar", image: "TeamMember2" },
  { name: "Sumit Mathankar", image: "TeamMember2" },
  { name: "Ankit Korde", image: "TeamMember2" },
  { name: "Swapnali Morbale", image: "TeamMember2" },
  { name: "Abhishek Mishra", image: "TeamMember2" },
  { name: "Asim", image: "TeamMember2" },
  { name: "Vishalsinh Chandel", image: "TeamMember2" },
  { name: "Aryan Bisht", image: "TeamMember2" },
];

export default function TeamCarousel() {
  const [index, setIndex] = useState(0);

  useEffect(() => {
    const interval = setInterval(() => {
      setIndex((prevIndex) => (prevIndex + 1) % teamMembers.length);
    }, 3000);
    return () => clearInterval(interval);
  }, []);

  return (
    <div className="relative w-full flex flex-col items-center overflow-hidden">
      <h2 className="text-xl font-bold mb-4">Meet Our Team</h2>
      <div className="relative flex items-center justify-center w-full max-w-lg h-72">
        <AnimatePresence>
          {teamMembers.map((member, i) => (
            <motion.div
              key={i}
              className={`absolute flex flex-col items-center transition-all ${
                i === index ? "scale-110 z-10" : "scale-75 opacity-50"
              }`}
              initial={{ opacity: 0, scale: 0.75 }}
              animate={{ opacity: i === index ? 1 : 0.5, scale: i === index ? 1.1 : 0.75 }}
              exit={{ opacity: 0, scale: 0.75 }}
              transition={{ duration: 0.8 }}
            >
              <img
                src={member.image}
                alt={member.name}
                className="w-32 h-32 rounded-full shadow-lg object-cover"
              />
              <h3 className="mt-2 text-lg font-semibold">{member.name}</h3>
            </motion.div>
          ))}
        </AnimatePresence>
      </div>
    </div>
  );
}
